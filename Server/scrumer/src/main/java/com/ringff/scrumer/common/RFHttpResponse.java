package com.ringff.scrumer.common;

import com.fasterxml.jackson.annotation.JsonProperty;
import com.fasterxml.jackson.annotation.JsonPropertyOrder;

/**
 * Ringff http response
 * @author Eric Zhao 
 *
 * @param <T>
 */
@JsonPropertyOrder({RFHttpResponse.Field_header, BaseResponse.Field_data})
public class RFHttpResponse<T> extends BaseResponse<T> {

    public static final String Field_header = "header";
    
    private ResponseHeader header;
    
    private RFHttpResponse(){
        this.header = new ResponseHeader();
    }
    
    public static <T>  RFHttpResponse<T> build(){
        return new RFHttpResponse<>();
    }
    
    public RFHttpResponse<T> setStatus(EnumResponseStatus status){
        this.header.setStatus(status);
        return this;
    }
    public RFHttpResponse<T> setMessage(String message){
        this.header.setMessage(message);
        return this;
    }
    
    @JsonProperty(RFHttpResponse.Field_header)
    public ResponseHeader getHeader(){
        return this.header;
    }
    
}
