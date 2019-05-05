package com.ringff.scrumer.controller;

import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.servlet.ModelAndView;

import com.ringff.scrumer.message.XPokerWebSocketServer;
import com.ringff.scrumer.po.MessagePO;

@Controller
@RequestMapping("home")
public class HomeController extends BaseController {

    @GetMapping("ws/{cid}")
    public ModelAndView ws(@PathVariable String cid){
        ModelAndView mv = new ModelAndView();
        mv.setViewName("ws");
        mv.addObject("cid",cid);
        return mv;
    }
    
    @ResponseBody
    @RequestMapping("ws/push/{cid}")
    public MessagePO pushMessage(@PathVariable String cid,String message){
        XPokerWebSocketServer.sendBatchMessage(message, cid);
        
        MessagePO model = new MessagePO(cid, message);
        return model;
    }
}
