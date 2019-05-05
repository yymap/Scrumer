package com.ringff.scrumer.common;

public enum EnumResponseStatus {
    
    Success("0000","Success"),
    /**
     * 9000 ---- 9999 Represent various errors.
     */
    Error("9000","Error");
    

    private String value;
    private String desc;
    
    private EnumResponseStatus(String value,String desc){
        this.value = value;
        this.desc = desc;
    }
    
    public String getValue() {
        return value;
    }



    public String getDesc() {
        return desc;
    }
    
    
    @Override
    public String toString() {
        return value;
    }
    
}
