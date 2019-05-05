package com.ringff.scrumer.service.impl;

import java.util.List;

import org.apache.ibatis.session.SqlSession;
import org.springframework.stereotype.Component;

import com.ringff.scrumer.dao.DBUtil;
import com.ringff.scrumer.mapper.StoryMapper;
import com.ringff.scrumer.po.StoryPO;
import com.ringff.scrumer.service.StoryService;

@Component
public class StoryServiceImpl extends BaseService implements StoryService {

    @Override
    public int add(StoryPO obj) {
        SqlSession session = null;
        
        try{
            session = DBUtil.openSqlSession();
            
            StoryMapper mapper = session.getMapper(StoryMapper.class);
            int ret = mapper.add(obj);
            session.commit();
            if(ret > 0){
                return obj.getId();
            }
            return ret;
        }
        catch(Exception ex){
            this.logger.error("Add story info error.", ex);
            return -1;
        }
        finally{
            if(session != null){
                session.close();
            }
        }
    }

    @Override
    public StoryPO getOne(int id) {
        SqlSession session = null;
        
        try{
            session = DBUtil.openSqlSession();
            
            StoryMapper mapper = session.getMapper(StoryMapper.class);
            return mapper.getOne(id);
        }
        catch(Exception ex){
            this.logger.error("Get story info error.", ex);
            return null;
        }
        finally{
            if(session != null){
                session.close();
            }
        }
    }

    @Override
    public List<StoryPO> getList(StoryPO query) {
        SqlSession session = null;
        
        try{
            session = DBUtil.openSqlSession();
            
            StoryMapper mapper = session.getMapper(StoryMapper.class);
            return mapper.getList(query);
        }
        catch(Exception ex){
            this.logger.error("Get story list info error.", ex);
            return null;
        }
        finally{
            if(session != null){
                session.close();
            }
        }
    }

    @Override
    public int modify(StoryPO obj) {
        SqlSession session = null;
        
        try{
            session = DBUtil.openSqlSession();
            
            StoryMapper mapper = session.getMapper(StoryMapper.class);
            int ret = mapper.modify(obj);
            session.commit();
            return ret;
        }
        catch(Exception ex){
            this.logger.error("Update story info error.", ex);
            return -1;
        }
        finally{
            if(session != null){
                session.close();
            }
        }
    }

}
