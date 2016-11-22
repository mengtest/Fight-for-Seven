package com.FightforSeven.server;

import com.FightforSeven.handler.LoginHandler;
import com.FightforSeven.handler.RegisterHandler;
import com.FightforSeven.handler.ResetHandler;
import com.FightforSeven.model.SocketModel;
import com.FightforSeven.protocol.Protocol;

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
	public void channelActive(ChannelHandlerContext ctx) throws Exception // 当客户端连上服务器的时候会触发此函数
	{
		System.out.println("client:" + ctx.channel().id() + " join server");
	}

	@Override
	public void channelInactive(ChannelHandlerContext ctx) throws Exception// 当客户端断开连接的时候触发函数
	{
		System.out.println("client:" + ctx.channel().id() + " leave server");
	}

	@Override
	public void channelRead(ChannelHandlerContext ctx, Object msg) throws Exception// 当客户端发送数据到服务器会触发此函数
	{
		SocketModel message = (SocketModel) msg;
		switch (message.getType()) {
		case Protocol.TYPE_LOGIN:
			LoginHandler.getInstance().dispatch(ctx, message);
			break;
		case Protocol.TYPE_REGISTER:
			RegisterHandler.getInstance().dispatch(ctx, message);
			break;
		case Protocol.TYPE_RESET:
			ResetHandler.getInstance().dispatch(ctx, message);
			break;
		default:
			break;
		}
	}

	@Override
	public void exceptionCaught(ChannelHandlerContext ctx, Throwable cause) throws Exception {
		cause.printStackTrace();
	}

}
