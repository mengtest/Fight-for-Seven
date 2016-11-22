package com.FightforSeven.decoder;

import java.util.List;

import com.FightforSeven.model.SocketModel;
import com.dyuproject.protostuff.ProtobufIOUtil;
import com.dyuproject.protostuff.Schema;
import com.dyuproject.protostuff.runtime.RuntimeSchema;

import io.netty.buffer.ByteBuf;
import io.netty.channel.ChannelHandlerContext;
import io.netty.handler.codec.ByteToMessageDecoder;

/** 
 * @author  ���ߣ�littleredhat
 * @date ����ʱ�䣺2016��11��20�� ����11:25:10 
 * @version 1.0 
 *
 */
public class MessageDecoder extends ByteToMessageDecoder{
    private Schema<SocketModel> schema = RuntimeSchema.getSchema(SocketModel.class);
    
	@Override
	protected void decode(ChannelHandlerContext ctx, ByteBuf in, List<Object> obj) throws Exception {
		byte[] data = new byte[in.readableBytes()];
		in.readBytes(data);
		SocketModel message = new SocketModel();
		ProtobufIOUtil.mergeFrom(data, message, schema);
		obj.add(message);
	}

}
