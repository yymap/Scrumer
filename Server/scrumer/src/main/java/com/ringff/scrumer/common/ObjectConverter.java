package com.ringff.scrumer.common;

import java.lang.reflect.Field;
import java.util.HashMap;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;


public final class ObjectConverter {
    private ObjectConverter() { }
    private static Logger logger = LoggerFactory.getLogger(ObjectConverter.class);

    /**
     * Convert an object to another Type instance.
     * This method only set field value which have same name in both types.
     * @param fromObj
     * @param tToClass
     * @return
     * @throws InstantiationException
     * @throws IllegalAccessException
     */
    public static <TTo extends Object> TTo convert(Object fromObj,Class<TTo> tToClass){

        TTo toObj = null;
        try{
            toObj = tToClass.newInstance();
        }
        catch(Exception ex){
            logger.error("Initialize object error.", ex);
            return toObj;
        }

        Class<?> fromClass = fromObj.getClass();
        if (fromClass.isPrimitive()) {
            return toObj;
        }

        HashMap<String, Field> fromFieldMap = new HashMap<>();
        for (Field f : fromClass.getDeclaredFields()) {
            fromFieldMap.put(f.getName(), f);
        }

        try{
            for (Field toObjField : tToClass.getDeclaredFields()) {
                if (!fromFieldMap.containsKey(toObjField.getName())) {
                    continue;
                }
                toObjField.setAccessible(true);
                fromFieldMap.get(toObjField.getName()).setAccessible(true);
                toObjField.set(toObj, fromFieldMap.get(toObjField.getName()).get(fromObj));
            } // for
        }
        catch(Exception ex){
            logger.error("Convert object error.", ex);
        }

        return toObj;
    }
}
