package com.ringff.scrumer.dao;


import java.io.IOException;
import java.io.InputStream;

import org.apache.ibatis.io.Resources;
import org.apache.ibatis.session.SqlSession;
import org.apache.ibatis.session.SqlSessionFactory;
import org.apache.ibatis.session.SqlSessionFactoryBuilder;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

public final class DBUtil {
    private static Logger logger = LoggerFactory.getLogger(DBUtil.class);

    private DBUtil(){}
    
    private final static String MYBATIS_CONFIG_FILE = "mybatis-config.xml";
    
    private static SqlSessionFactory sqlSessionFactory;
    
    private final static Class<?> CLASS_LOCK = DBUtil.class;
    
    private static void initSqlSessionFactory(){
        InputStream is = null;
        try{
            is = Resources.getResourceAsStream(MYBATIS_CONFIG_FILE);
        }
        catch(IOException ioEx){
           logger.error("getResourceAsStream error.",ioEx);
        }
        
        if(sqlSessionFactory == null){
            synchronized(CLASS_LOCK){
                if(sqlSessionFactory == null){
                    sqlSessionFactory = new SqlSessionFactoryBuilder().build(is);
                }
            }
        }
    }
    
    public static SqlSession openSqlSession(){
        if(sqlSessionFactory == null){
            initSqlSessionFactory();
        }
        return sqlSessionFactory.openSession();
    }
    
}
