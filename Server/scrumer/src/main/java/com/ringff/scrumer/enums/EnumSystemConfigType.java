package com.ringff.scrumer.enums;

public enum EnumSystemConfigType {
    System,
    Updater;
    
    public static EnumSystemConfigType getEnumSystemConfigType(int ordinal){
        if(ordinal == 0){
            return EnumSystemConfigType.System;
        }
        if(ordinal == 1){
            return EnumSystemConfigType.Updater;
        }
        return null;
    }
}