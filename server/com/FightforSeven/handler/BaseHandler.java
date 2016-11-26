package com.FightforSeven.handler;

import com.FightforSeven.model.SocketModel;

import io.netty.channel.ChannelHandlerContext;

/** 
 * @author  作者：littleredhat
 * @date 创建时间：2016年11月25日 上午10:50:58 
 * @version 1.0 
 *
 */
public abstract class BaseHandler {
	public abstract int getType();

	public abstract void dispatch(ChannelHandlerContext ctx, SocketModel message);
}
