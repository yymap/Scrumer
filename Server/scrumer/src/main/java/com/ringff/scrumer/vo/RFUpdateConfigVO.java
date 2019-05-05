package com.ringff.scrumer.vo;

import java.util.List;

import com.fasterxml.jackson.annotation.JsonProperty;
import com.ringff.scrumer.po.SystemConfigPO;
import com.ringff.scrumer.util.RFCollectionUtil;

public class RFUpdateConfigVO extends BaseVO  {
    
    public static final String Field_mssql_conn_str = "mssql_conn_str";

    private String msSqlConnStr;

    @JsonProperty(Field_mssql_conn_str)
    public String getMsSqlConnStr() {
        return msSqlConnStr;
    }

    public void setMsSqlConnStr(String msSqlConnStr) {
        this.msSqlConnStr = msSqlConnStr;
    }
    
    public static RFUpdateConfigVO from(List<SystemConfigPO> poList){
        RFUpdateConfigVO vo = new  RFUpdateConfigVO();
        
        if(RFCollectionUtil.isNullOrEmpty(poList)){
            return vo;
        }
        
        for(SystemConfigPO po : poList){
            if(po.getName().equals("ms_sql_connection_string")){
                vo.setMsSqlConnStr(po.getValue());
            }
        }
        
        return vo;
    }
}
