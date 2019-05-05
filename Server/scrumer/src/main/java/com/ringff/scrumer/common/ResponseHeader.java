package com.ringff.scrumer.common;

import com.fasterxml.jackson.annotation.JsonInclude;
import com.fasterxml.jackson.annotation.JsonProperty;
import com.fasterxml.jackson.annotation.JsonInclude.Include;

@JsonInclude(Include.NON_NULL)
public class ResponseHeader {
    
    @JsonProperty("status")
    private EnumResponseStatus status = EnumResponseStatus.Success;
    
    @JsonProperty("message")
    private String message = "";
    
    
    public EnumResponseStatus getStatus() {
        return status;
    }
    public void setStatus(EnumResponseStatus code) {
        this.status = code;
    }
    public String getMessage() {
        return message;
    }
    public void setMessage(String message) {
        this.message = message;
    }
   
}
