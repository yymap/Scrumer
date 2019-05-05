package com.ringff.scrumer.vo;

import java.util.Date;

import com.fasterxml.jackson.annotation.JsonProperty;

public class StoryVO extends BaseVO{

    @JsonProperty("id")
    private int id;
    
    @JsonProperty("name")
    private String name;
    
    @JsonProperty("project_id")
    private int projectId;
    
    @JsonProperty("link_url")
    private String linkUrl;
    
    @JsonProperty("content")
    private String content;
    
    @JsonProperty("developer")
    private String developer;
    
    @JsonProperty("qa")
    private String qa;
    
    @JsonProperty("point")
    private float point;
    
    @JsonProperty("dev_plan_time")
    private float devPlanTime;
    
    @JsonProperty("dev_spend_time")
    private float devSpendTime;
    
    @JsonProperty("qa_plan_time")
    private float qaPlanTime;
    
    @JsonProperty("qa_spend_time")
    private float qaSpendTime;
    
    @JsonProperty("isd_count")
    private int isdCount;
    
    @JsonProperty("create_date")
    private Date createDate;
    
    @JsonProperty("create_by")
    private String createBy;
    
    @JsonProperty("update_date")
    private Date updateDate;
    
    @JsonProperty("update_by")
    private String updateBy;
    
    public int getId() {
        return id;
    }
    public void setId(int id) {
        this.id = id;
    }
    public String getName() {
        return name;
    }
    public void setName(String name) {
        this.name = name;
    }
    public int getProjectId() {
        return projectId;
    }
    public void setProjectId(int projectId) {
        this.projectId = projectId;
    }
    public String getLinkUrl() {
        return linkUrl;
    }
    public void setLinkUrl(String linkUrl) {
        this.linkUrl = linkUrl;
    }
    public String getContent() {
        return content;
    }
    public void setContent(String content) {
        this.content = content;
    }
    public String getDeveloper() {
        return developer;
    }
    public void setDeveloper(String developer) {
        this.developer = developer;
    }
    public String getQa() {
        return qa;
    }
    public void setQa(String qa) {
        this.qa = qa;
    }
    public float getPoint() {
        return point;
    }
    public void setPoint(float point) {
        this.point = point;
    }
    public float getDevPlanTime() {
        return devPlanTime;
    }
    public void setDevPlanTime(float devPlanTime) {
        this.devPlanTime = devPlanTime;
    }
    public float getDevSpendTime() {
        return devSpendTime;
    }
    public void setDevSpendTime(float devSpendTime) {
        this.devSpendTime = devSpendTime;
    }
    public float getQaPlanTime() {
        return qaPlanTime;
    }
    public void setQaPlanTime(float qaPlanTime) {
        this.qaPlanTime = qaPlanTime;
    }
    public float getQaSpendTime() {
        return qaSpendTime;
    }
    public void setQaSpendTime(float qaSpendTime) {
        this.qaSpendTime = qaSpendTime;
    }
    public int getIsdCount() {
        return isdCount;
    }
    public void setIsdCount(int isdCount) {
        this.isdCount = isdCount;
    }
    public Date getCreateDate() {
        return createDate;
    }
    public void setCreateDate(Date createDate) {
        this.createDate = createDate;
    }
    public String getCreateBy() {
        return createBy;
    }
    public void setCreateBy(String createBy) {
        this.createBy = createBy;
    }
    public Date getUpdateDate() {
        return updateDate;
    }
    public void setUpdateDate(Date updateDate) {
        this.updateDate = updateDate;
    }
    public String getUpdateBy() {
        return updateBy;
    }
    public void setUpdateBy(String updateBy) {
        this.updateBy = updateBy;
    }
}
