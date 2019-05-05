package com.ringff.scrumer.service.impl;

import java.util.List;

import org.apache.ibatis.session.SqlSession;

import org.springframework.stereotype.Component;

import com.ringff.scrumer.dao.DBUtil;
import com.ringff.scrumer.enums.EnumSystemConfigType;
import com.ringff.scrumer.mapper.SystemConfigPOMapper;
import com.ringff.scrumer.po.SystemConfigPO;
import com.ringff.scrumer.service.ConfigService;

@Component
public class ConfigServiceImpl extends BaseService implements ConfigService {
    
    @Override
    public List<SystemConfigPO> getSystemConfigs(EnumSystemConfigType type) {
        List<SystemConfigPO> ret = null;
        SqlSession session = null;
        
        try{
            session = DBUtil.openSqlSession();
            SystemConfigPOMapper mapper = session.getMapper(SystemConfigPOMapper.class);
            ret = mapper.select(EnumSystemConfigType.Updater);
        }
        catch(Exception ex){
            this.logger.error("Get system config info error.", ex);
        }
        finally{
            if(session != null){
                session.close();
            }
        }
        
        return ret;
    }
    
}
