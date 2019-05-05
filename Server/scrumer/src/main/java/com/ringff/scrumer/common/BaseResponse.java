package com.ringff.scrumer.common;

import java.util.HashMap;

import com.fasterxml.jackson.annotation.JsonProperty;

public abstract class BaseResponse<T> {
    
    public static final String Field_data = "data";
    
    protected HashMap<String, T> data;
    
    public BaseResponse(){
        data = new HashMap<>();
    }

    public void putData(String dataItemName, T dataItem){
        this.data.put(dataItemName, dataItem);
    }
    

    @JsonProperty(BaseResponse.Field_data)
    public HashMap<String, T> getData(){
        return this.data;
    }

}
