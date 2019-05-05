package com.ringff.scrumer.controller;

import java.util.ArrayList;
import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;

import com.ringff.scrumer.common.EnumResponseStatus;
import com.ringff.scrumer.common.ObjectConverter;
import com.ringff.scrumer.common.RFHttpResponse;
import com.ringff.scrumer.po.StoryPO;
import com.ringff.scrumer.service.StoryService;
import com.ringff.scrumer.vo.StoryVO;

@RestController
@RequestMapping("story")
public class StoryController extends BaseController{

    @Autowired
    private StoryService storyService;
    
    @RequestMapping(method = RequestMethod.POST)
    public RFHttpResponse<Integer> addStory(@RequestBody StoryVO vo){
        RFHttpResponse<Integer> res = RFHttpResponse.build();
        
        StoryPO po = ObjectConverter.convert(vo, StoryPO.class);
        
        int newId = storyService.add(po);
        
        if(newId <= 0){
            res.setStatus(EnumResponseStatus.Error);
            res.setMessage("Add story failed.Please contact admin.");
            return res;
        }
        
        res.putData("id", newId);
        return res;
    }
    
    @RequestMapping(method = RequestMethod.PUT)
    public RFHttpResponse<Integer> modifyStory(@RequestBody StoryVO vo){
        RFHttpResponse<Integer> res = RFHttpResponse.build();
        
        StoryPO po = ObjectConverter.convert(vo, StoryPO.class);
        
        int newId = storyService.modify(po);
        
        if(newId <= 0){
            res.setStatus(EnumResponseStatus.Error);
            res.setMessage("Modify story failed.Please contact admin.");
            return res;
        }

        return res;
    }
    
    @RequestMapping(method = RequestMethod.GET)
    public RFHttpResponse<List<StoryVO>> getStoryList(StoryVO vo){
        RFHttpResponse<List<StoryVO>> res = RFHttpResponse.build();
        
        StoryPO po = ObjectConverter.convert(vo, StoryPO.class);
        
        List<StoryPO> poList  = storyService.getList(po);
        
        if(poList == null){
            res.setStatus(EnumResponseStatus.Error);
            res.setMessage("Add story list failed.Please contact admin.");
            return res;
        }
        
        List<StoryVO> list = new ArrayList<>();
        poList.forEach(poObj -> list.add((ObjectConverter.convert(poObj, StoryVO.class))));
        
        res.putData("story", list);

        return res;
    }
    
    @RequestMapping(value="single",method = RequestMethod.GET)
    public RFHttpResponse<StoryPO> getOneStory(@PathVariable("id") int id){
        RFHttpResponse<StoryPO> res = RFHttpResponse.build();
        
        StoryPO obj  = storyService.getOne(id);
        
        if(obj == null){
            res.setStatus(EnumResponseStatus.Error);
            res.setMessage("Get story failed.Please contact admin.");
            return res;
        }
        res.putData("story", obj);

        return res;
    }
}
