package com.ringff.scrumer.vo;

import java.util.Date;

import com.fasterxml.jackson.annotation.JsonProperty;
import com.ringff.scrumer.po.UserLoginPO;

public class UserLoginVO extends BaseVO{
    
    public final static String Field_id = "id";
    public final static String Field_name = "name";
    public final static String Field_mobile = "mobile";
    public final static String Field_password = "password";
    public final static String Field_sub_password = "sub_password";
    public final static String Field_create_date = "create_date";
    public final static String Field_update_date = "update_date";

    @JsonProperty(Field_id)
    private int id;
    @JsonProperty(Field_name)
    private String name;
    @JsonProperty(Field_mobile)
    private String mobile;
    @JsonProperty(Field_password)
    private String password;
    @JsonProperty(Field_sub_password)
    private String subPassword;
    @JsonProperty(Field_create_date)
    private Date createDate;
    @JsonProperty(Field_update_date)
    private Date updateDate;
    
    public int getId() {
        return id;
    }
    public void setId(int id) {
        this.id = id;
    }
    public String getName() {
        return name;
    }
    public void setName(String name) {
        this.name = name;
    }
    public String getMobile() {
        return mobile;
    }
    public void setMobile(String mobile) {
        this.mobile = mobile;
    }
    public String getPassword() {
        return password;
    }
    public void setPassword(String password) {
        this.password = password;
    }
    public String getSubPassword() {
        return subPassword;
    }
    public void setSubPassword(String subPassword) {
        this.subPassword = subPassword;
    }
    public Date getCreateDate() {
        return createDate;
    }
    public void setCreateDate(Date createDate) {
        this.createDate = createDate;
    }
    public Date getUpdateDate() {
        return updateDate;
    }
    public void setUpdateDate(Date updateDate) {
        this.updateDate = updateDate;
    }
    
    public static UserLoginVO fromUserLoginPO(UserLoginPO po){
        UserLoginVO vo = new UserLoginVO();
        
        vo.setId(po.getId());
        vo.setName(po.getName());
        vo.setMobile(po.getMobile());
        vo.setPassword(po.getPassword());
        vo.setSubPassword(po.getSubPassword());
        vo.setCreateDate(po.getCreateDate());
        vo.setUpdateDate(po.getUpdateDate());
        
        return vo;
    }
}
