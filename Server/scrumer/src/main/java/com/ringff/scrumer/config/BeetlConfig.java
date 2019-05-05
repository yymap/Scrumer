package com.ringff.scrumer.config;

import org.beetl.core.resource.ClasspathResourceLoader;
import org.beetl.ext.spring.BeetlGroupUtilConfiguration;
import org.beetl.ext.spring.BeetlSpringViewResolver;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

@Configuration
public class BeetlConfig {
    
    @Value("${beetl.templatesPath}") String templatesPath;
    
    @Bean
    public BeetlGroupUtilConfiguration getBeetlGroupUtilConfiguration(){
        BeetlGroupUtilConfiguration confg = new BeetlGroupUtilConfiguration();
        
        ClassLoader classLoader = Thread.currentThread().getContextClassLoader();
        if(classLoader == null){
            classLoader = BeetlConfig.class.getClassLoader();
        }
        ClasspathResourceLoader rcLoader = new ClasspathResourceLoader(classLoader,templatesPath);
        confg.setResourceLoader(rcLoader);
        confg.init();
        
        confg.getGroupTemplate().setClassLoader(classLoader);
        
        return confg;
    }
    
    @Bean
    public BeetlSpringViewResolver getBeetlSpringViewResolver(BeetlGroupUtilConfiguration beetlGroupUtilConfiguration ){
        BeetlSpringViewResolver vResolver = new BeetlSpringViewResolver();
        //if beetl.properties specify RESOURCE.root=/templates/, need comment below code line.
        //vResolver.setPrefix("/templates/");
        vResolver.setSuffix(".html");
        vResolver.setContentType("text/html;charset=UTF-8");
        vResolver.setOrder(0);
        vResolver.setConfig(beetlGroupUtilConfiguration);
        
        return vResolver;
    }
}