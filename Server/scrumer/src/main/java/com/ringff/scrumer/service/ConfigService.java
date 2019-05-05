package com.ringff.scrumer.service;

import java.util.List;

import com.ringff.scrumer.enums.EnumSystemConfigType;
import com.ringff.scrumer.po.SystemConfigPO;

public interface ConfigService {
    
    
    List<SystemConfigPO> getSystemConfigs(EnumSystemConfigType type);
}

