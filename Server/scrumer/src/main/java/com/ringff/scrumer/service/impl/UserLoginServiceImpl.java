package com.ringff.scrumer.service.impl;

import org.apache.ibatis.session.SqlSession;
import org.springframework.stereotype.Component;

import com.ringff.scrumer.dao.DBUtil;
import com.ringff.scrumer.mapper.UserLoginPOMapper;
import com.ringff.scrumer.po.UserLoginPO;
import com.ringff.scrumer.service.UserLoginService;

@Component
public class UserLoginServiceImpl extends BaseService implements UserLoginService{

    @Override
    public int add(UserLoginPO user) {
        
        SqlSession session = null;
        
        try{
            session = DBUtil.openSqlSession();
            
            UserLoginPOMapper mapper = session.getMapper(UserLoginPOMapper.class);
            int ret = mapper.add(user);
            session.commit();
            return ret;
        }
        catch(Exception ex){
            this.logger.error("Add user info error.", ex);
            return -1;
        }
        finally{
            if(session != null){
                session.close();
            }
        }
    }

    @Override
    public UserLoginPO getOne(int id) {
        SqlSession session = null;
        
        try{
            session = DBUtil.openSqlSession();
            
            UserLoginPOMapper mapper = session.getMapper(UserLoginPOMapper.class);
            return mapper.getOne(id);
        }
        catch(Exception ex){
            this.logger.error("Get user info error.", ex);
            return null;
        }
        finally{
            if(session != null){
                session.close();
            }
        }
    }

    @Override
    public UserLoginPO login(String name, String pwd) {
        SqlSession session = null;
        
        try{
            session = DBUtil.openSqlSession();
            
            UserLoginPOMapper mapper = session.getMapper(UserLoginPOMapper.class);
            return mapper.login(name, pwd);
        }
        catch(Exception ex){
            this.logger.error("Login error.", ex);
            throw ex;
        }
        finally{
            if(session != null){
                session.close();
            }
        }
    }

}
