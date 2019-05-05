package com.ringff.scrumer.mapper;

import java.util.List;


import com.ringff.scrumer.po.StoryPO;

public interface StoryMapper {

    //@Options(useGeneratedKeys = true, keyProperty= "obj.id")
    int add(StoryPO obj);
    StoryPO getOne(int id);
    List<StoryPO> getList(StoryPO query);
    int modify(StoryPO obj);
}
