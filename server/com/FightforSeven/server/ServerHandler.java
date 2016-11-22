package com.FightforSeven.server;

import com.FightforSeven.handler.LoginHandler;
import com.FightforSeven.handler.RegisterHandler;
import com.FightforSeven.handler.ResetHandler;
import com.FightforSeven.model.SocketModel;
import com.FightforSeven.protocol.Protocol;

import io.netty.channel.ChannelHandlerAdapter;
import io.netty.channel.ChannelHandlerContext;

/**
 * @author ���ߣ�littleredhat
 * @date ����ʱ�䣺2016��11��21�� ����12:16:50
 * @version 1.0
 *
 */
public class ServerHandler extends ChannelHandlerAdapter {
	@Override
	public void channelActive(ChannelHandlerContext ctx) throws Exception // ���ͻ������Ϸ�������ʱ��ᴥ���˺���
	{
		System.out.println("client:" + ctx.channel().id() + " join server");
	}

	@Override
	public void channelInactive(ChannelHandlerContext ctx) throws Exception// ���ͻ��˶Ͽ����ӵ�ʱ�򴥷�����
	{
		System.out.println("client:" + ctx.channel().id() + " leave server");
	}

	@Override
	public void channelRead(ChannelHandlerContext ctx, Object msg) throws Exception// ���ͻ��˷������ݵ��������ᴥ���˺���
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
