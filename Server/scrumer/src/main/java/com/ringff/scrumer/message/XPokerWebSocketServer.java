package com.ringff.scrumer.message;


import java.io.IOException;
import java.util.concurrent.ConcurrentHashMap;

import javax.websocket.OnClose;
import javax.websocket.OnError;
import javax.websocket.OnMessage;
import javax.websocket.OnOpen;
import javax.websocket.Session;
import javax.websocket.server.PathParam;
import javax.websocket.server.ServerEndpoint;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.stereotype.Component;

@ServerEndpoint("/ws/{sid}")
@Component
public class XPokerWebSocketServer {

    private static Logger logger = LoggerFactory.getLogger(XPokerWebSocketServer.class);
    
    private static int onlineCount =0;
    
    private static ConcurrentHashMap<String, XPokerWebSocketServer> webSocketSet = new ConcurrentHashMap<>();
    
    private Session session;
    private String sid;
    
    @OnOpen
    public void onOpen(Session session, @PathParam("sid") String sid){
        this.session = session;
        webSocketSet.put(sid, this);
        addOnlineCount();
        logger.info("sid=" + sid + ",online count =" + getOnlineCount());
        this.sid = sid;
        try{
            sendMessage("Connection connected, sid=" + sid);
        }
        catch(Exception e){
            logger.error("onOpen", e);
        }
    }
    
    @OnClose
    public void onClose(){
        webSocketSet.remove(this.sid);
        subOnlineCount();
        logger.info("Connection closed,sid=" + sid);
    }
    
    @OnMessage
    public void onMessage(String msg,Session session){
        logger.info("Receive message from " + sid+ ":" + msg);
        
        sendBatchMessage(msg, null);
    }
    
    @OnError
    public void onError(Session session,Throwable ex){
        logger.error("Unexpected error.",ex);
    }
    
    /**
     * Server send message to client
     * @param msg
     * @throws IOException
     */
    private void sendMessage(String msg) throws IOException{
        this.session.getBasicRemote().sendText(msg);
    }
    
    public static void sendBatchMessage(String msg,@PathParam("sid") String sid){
        logger.info("Send message to " + sid + ",content:" + msg);
        
        for(XPokerWebSocketServer server : webSocketSet.values()){
            try{
                if(sid == null){
                    server.sendMessage(msg);
                }
                else if(sid.equals(server.sid)){
                    server.sendMessage(msg);
                }
            }
            catch(IOException ioe){
                logger.error("Error from sendBatchMessage",ioe);
                continue;
            }
        }//for
    }
    
    private synchronized static int getOnlineCount(){
        return XPokerWebSocketServer.onlineCount;
    }
    
    private synchronized static void addOnlineCount(){
        XPokerWebSocketServer.onlineCount ++;
    }
    
    private synchronized static void subOnlineCount(){
        XPokerWebSocketServer.onlineCount --;
    }
}