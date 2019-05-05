package com.ringff.scrumer.po;

import java.util.Date;


import org.apache.ibatis.type.Alias;


@Alias("StoryPO")
public class StoryPO extends BasePO{

    private int id;
    private String name;
    private int projectId;
    private String linkUrl;
    private String content;
    private String developer;
    private String qa;
    private float point;
    private float devPlanTime;
    private float devSpendTime;
    private float qaPlanTime;
    private float qaSpendTime;
    private int isdCount;
    private Date createDate;
    private String createBy;
    private Date updateDate;
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
