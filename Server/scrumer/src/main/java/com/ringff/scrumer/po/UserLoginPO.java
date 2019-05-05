package com.ringff.scrumer.po;

import java.util.Date;

import org.apache.ibatis.type.Alias;

import com.ringff.scrumer.vo.UserLoginVO;

@Alias("UserLoginPO")
public class UserLoginPO extends BasePO {
   
    private int id;
    private String name;
    private String mobile;
    private String password;
    private String subPassword;
    private Date createDate;
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
    
    public static UserLoginPO fromUserLoginVO(UserLoginVO input){
        UserLoginPO ret = new UserLoginPO();
        
        ret.setId(input.getId());
        ret.setName(input.getName());
        ret.setMobile(input.getMobile());
        ret.setPassword(input.getPassword());
        ret.setSubPassword(input.getSubPassword());
        ret.setCreateDate(input.getCreateDate());
        ret.setUpdateDate(input.getUpdateDate());
        
        return ret;
    }
}
