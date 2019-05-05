package com.ringff.scrumer.mapper;

import org.apache.ibatis.annotations.Param;

import com.ringff.scrumer.po.UserLoginPO;

public interface UserLoginPOMapper {

    int add(UserLoginPO po);
    UserLoginPO getOne(int id);
    UserLoginPO login(@Param("name")String name,@Param("pwd")String pwd);
}
