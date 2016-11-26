package com.FightforSeven.handler;

import com.FightforSeven.model.SocketModel;

import io.netty.channel.ChannelHandlerContext;

/** 
 * @author  ���ߣ�littleredhat
 * @date ����ʱ�䣺2016��11��25�� ����10:50:58 
 * @version 1.0 
 *
 */
public abstract class BaseHandler {
	public abstract int getType();

	public abstract void dispatch(ChannelHandlerContext ctx, SocketModel message);
}
