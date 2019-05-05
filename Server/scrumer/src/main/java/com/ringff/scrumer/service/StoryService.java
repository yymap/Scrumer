package com.ringff.scrumer.service;

import java.util.List;

import com.ringff.scrumer.po.StoryPO;

public interface StoryService {

    int add(StoryPO obj);
    StoryPO getOne(int id);
    
    List<StoryPO> getList(StoryPO query);
    int modify(StoryPO obj);
}
