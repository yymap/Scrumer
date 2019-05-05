package com.ringff.scrumer.util;


import java.lang.reflect.Array;
import java.util.Collection;

public final class RFCollectionUtil {
    private RFCollectionUtil(){}
    
    public static boolean isNullOrEmpty(Object obj){
        if(obj == null){
            return true;
        }
        
        if (obj instanceof String) {
            return  obj == "";
        }
        
        if (Collection.class.isAssignableFrom(obj.getClass())) {
            return ((Collection)obj).size() == 0;
        }
        
        if (obj.getClass().isArray()) {
            return Array.getLength(obj) == 0;
        }
        
        return false;
    }
}
