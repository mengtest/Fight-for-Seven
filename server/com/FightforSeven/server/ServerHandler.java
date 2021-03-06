package com.FightforSeven.server;

import com.FightforSeven.handler.BaseHandler;
import com.FightforSeven.model.SocketModel;

import io.netty.channel.ChannelHandlerAdapter;
import io.netty.channel.ChannelHandlerContext;

/**
 * @author 作者：littleredhat
 * @date 创建时间：2016年11月21日 上午12:16:50
 * @version 1.0
 *
 */
public class ServerHandler extends ChannelHandlerAdapter {
	
	@Override
	public void channelActive(ChannelHandlerContext ctx) throws Exception  //当客户端连上服务器的时候会触发此函数
	{
		System.out.println("client:" + ctx.channel().id() + " join server");
		MainServer.getInstance().channels.add(ctx.channel());
	}

	@Override
	public void channelInactive(ChannelHandlerContext ctx) throws Exception  //当客户端断开连接的时候触发函数
	{
		System.out.println("client:" + ctx.channel().id() + " leave server");
		MainServer.getInstance().channels.remove(ctx.channel());
		MainServer.getInstance().account2channel.remove(MainServer.getInstance().channel2account.get(ctx.channel()));  //移除下线连接对应的账号
		MainServer.getInstance().channel2account.remove(ctx.channel());  //移除下线账号对应的连接
	}

	@Override
	public void channelRead(ChannelHandlerContext ctx, Object msg) throws Exception  //当客户端发送数据到服务器会触发此函数
	{
		SocketModel message = (SocketModel) msg;
		BaseHandler handler = MainServer.getInstance().handlers.get(message.getType());
		
		if(handler != null){
			String str = message.getType() + " " + message.getArea() + " " + message.getCommand();
			for (String strr : message.getMessage()) {
				str += strr + " ";
			}
			System.out.println(str);
			handler.dispatch(ctx, message);
		}else{
			System.out.println("no handler");
		}
	}

	@Override
	public void exceptionCaught(ChannelHandlerContext ctx, Throwable cause) throws Exception {
		cause.printStackTrace();
	}

}
