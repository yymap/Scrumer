package com.ringff.scrumer.po;

import org.apache.ibatis.type.Alias;

@Alias("MessagePO")
public class MessagePO extends BasePO {
    
    private String sid;
    private String message;
    
    public MessagePO(String sid,String message){
        this.sid = sid;
        this.message = message;
    }
    
    public String getSid() {
        return sid;
    }
    public void setSid(String sid) {
        this.sid = sid;
    }
    public String getMessage() {
        return message;
    }
    public void setMessage(String message) {
        this.message = message;
    }
    
    
}
