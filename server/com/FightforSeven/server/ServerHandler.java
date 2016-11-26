package com.FightforSeven.server;

import com.FightforSeven.handler.BaseHandler;
import com.FightforSeven.model.SocketModel;

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
	public void channelActive(ChannelHandlerContext ctx) throws Exception  //���ͻ������Ϸ�������ʱ��ᴥ���˺���
	{
		System.out.println("client:" + ctx.channel().id() + " join server");
		MainServer.getInstance().channels.add(ctx.channel());
	}

	@Override
	public void channelInactive(ChannelHandlerContext ctx) throws Exception  //���ͻ��˶Ͽ����ӵ�ʱ�򴥷�����
	{
		System.out.println("client:" + ctx.channel().id() + " leave server");
		MainServer.getInstance().channels.remove(ctx.channel());
	}

	@Override
	public void channelRead(ChannelHandlerContext ctx, Object msg) throws Exception  //���ͻ��˷������ݵ��������ᴥ���˺���
	{
		SocketModel message = (SocketModel) msg;
		BaseHandler handler = MainServer.getInstance().handlers.get(message.getType());
		if(handler != null){
			handler.dispatch(ctx, message);
		}
	}

	@Override
	public void exceptionCaught(ChannelHandlerContext ctx, Throwable cause) throws Exception {
		cause.printStackTrace();
	}

}
