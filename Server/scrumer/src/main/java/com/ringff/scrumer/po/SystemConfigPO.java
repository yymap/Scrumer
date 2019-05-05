package com.ringff.scrumer.po;

import java.util.Date;

import org.apache.ibatis.type.Alias;

import com.ringff.scrumer.enums.EnumSystemConfigType;

@Alias("SystemConfigPO")
public class SystemConfigPO extends BasePO {
    
    private int Id;
    private EnumSystemConfigType type;
    private String name;
    private String value;
    private Date createDate;
    
    public int getId() {
        return Id;
    }
    public void setId(int id) {
        Id = id;
    }
    public EnumSystemConfigType getType() {
        return type;
    }
    public void setType(EnumSystemConfigType type) {
        this.type = type;
    }
    public String getName() {
        return name;
    }
    public void setName(String name) {
        this.name = name;
    }
    public String getValue() {
        return value;
    }
    public void setValue(String value) {
        this.value = value;
    }
    public Date getCreateDate() {
        return createDate;
    }
    public void setCreateDate(Date createDate) {
        this.createDate = createDate;
    }
}
