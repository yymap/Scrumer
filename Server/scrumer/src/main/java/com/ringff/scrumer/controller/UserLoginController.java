package com.ringff.scrumer.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;

import com.ringff.scrumer.common.EnumResponseStatus;
import com.ringff.scrumer.common.RFHttpResponse;
import com.ringff.scrumer.po.UserLoginPO;
import com.ringff.scrumer.service.UserLoginService;
import com.ringff.scrumer.vo.UserLoginVO;

@RestController
@RequestMapping("user")
public class UserLoginController extends BaseController {
    
    @Autowired
    private UserLoginService userLoginService;
    
    @RequestMapping(method = RequestMethod.POST)
    public RFHttpResponse<UserLoginVO> addUserLogin(@RequestBody UserLoginVO vo){
        RFHttpResponse<UserLoginVO> res = RFHttpResponse.build();
        
        UserLoginPO po = UserLoginPO.fromUserLoginVO(vo);
        int userId = userLoginService.add(po);
        
        if(userId <= 0){
            res.setStatus(EnumResponseStatus.Error);
            res.setMessage("Add user failed.Please Contact Admin.");
            return res;
        }
        po.setId(userId);
        
        UserLoginVO retVo = UserLoginVO.fromUserLoginPO(po);
        res.putData("user", retVo);
        return res;
    }
    
    @RequestMapping(method = RequestMethod.GET)
    public RFHttpResponse<UserLoginVO> login(String name,String pwd){
        RFHttpResponse<UserLoginVO> res = RFHttpResponse.build();
        
        UserLoginPO po = null;
        try{
            po = userLoginService.login(name, pwd);
        }
        catch(Exception ex){
            res.setStatus(EnumResponseStatus.Error);
            res.setMessage("User Login Error.Please Contact Admin.");
            return res;
        }
        
        if(po == null){
            res.setStatus(EnumResponseStatus.Error);
            res.setMessage("Invalid name or password,Please try again.");
            return res;
        }
        
        UserLoginVO retVo = UserLoginVO.fromUserLoginPO(po);
        res.putData("user", retVo);
        return res;
    }
}
