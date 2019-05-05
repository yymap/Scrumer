package com.ringff.scrumer.service;

import com.ringff.scrumer.po.UserLoginPO;

public interface UserLoginService {

    int add(UserLoginPO user);
    UserLoginPO getOne(int id);
    UserLoginPO login(String name,String pwd);
}
