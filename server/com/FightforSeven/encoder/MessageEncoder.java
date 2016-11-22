package com.FightforSeven.encoder;

import com.FightforSeven.model.SocketModel;
import com.FightforSeven.util.CoderUtil;
import com.dyuproject.protostuff.LinkedBuffer;
import com.dyuproject.protostuff.ProtobufIOUtil;
import com.dyuproject.protostuff.Schema;
import com.dyuproject.protostuff.runtime.RuntimeSchema;

import io.netty.buffer.ByteBuf;
import io.netty.buffer.Unpooled;
import io.netty.channel.ChannelHandlerContext;
import io.netty.handler.codec.MessageToByteEncoder;

/**
 * @author 作者：littleredhat
 * @date 创建时间：2016年11月20日 下午11:29:51
 * @version 1.0
 *
 */
public class MessageEncoder extends MessageToByteEncoder<SocketModel> {
	private Schema<SocketModel> schema = RuntimeSchema.getSchema(SocketModel.class);

	@Override
	protected void encode(ChannelHandlerContext ctx, SocketModel message, ByteBuf out) throws Exception {
		LinkedBuffer buffer = LinkedBuffer.allocate(1024);
		byte[] data = ProtobufIOUtil.toByteArray(message, schema, buffer);
		ByteBuf buf = Unpooled.copiedBuffer(CoderUtil.intToBytes(data.length), data);
		out.writeBytes(buf);
	}
}
