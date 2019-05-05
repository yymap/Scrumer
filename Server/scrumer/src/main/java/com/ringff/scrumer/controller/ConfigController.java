package com.ringff.scrumer.controller;


import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.ringff.scrumer.common.RFHttpResponse;
import com.ringff.scrumer.enums.EnumSystemConfigType;
import com.ringff.scrumer.po.SystemConfigPO;
import com.ringff.scrumer.service.ConfigService;
import com.ringff.scrumer.vo.RFUpdateConfigVO;

@RestController
@RequestMapping("config")
public class ConfigController extends BaseController {
    
    @Autowired
    private ConfigService confgService;
    
    @RequestMapping("updater")
    public RFHttpResponse<RFUpdateConfigVO> getUpdaterConfig(){
        RFHttpResponse<RFUpdateConfigVO> response = RFHttpResponse.build();
        
        List<SystemConfigPO> poList = confgService.getSystemConfigs(EnumSystemConfigType.Updater);
        
        response.putData("config", RFUpdateConfigVO.from(poList));
        
        return response;
    }
    
}
