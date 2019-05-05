package com.ringff.scrumer.mapper;

import java.util.List;

import com.ringff.scrumer.enums.EnumSystemConfigType;
import com.ringff.scrumer.po.SystemConfigPO;

public interface SystemConfigPOMapper {

    int add(SystemConfigPO po);
    List<SystemConfigPO> select(EnumSystemConfigType type);
}
