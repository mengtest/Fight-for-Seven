package com.FightforSeven.handler;

import java.util.List;

import com.FightforSeven.manager.RoleManager;
import com.FightforSeven.model.SocketModel;
import com.FightforSeven.protocol.CreateProtocol;
import com.FightforSeven.protocol.Protocol;

import io.netty.channel.ChannelHandlerContext;

/** 
 * @author  作者：littleredhat
 * @date 创建时间：2016年11月25日 下午1:16:40 
 * @version 1.0 
 *
 */
public class CreateHandler extends BaseHandler {

	@Override
	public int getType() {
		return Protocol.TYPE_CREATE;
	}

	@Override
	public void dispatch(ChannelHandlerContext ctx, SocketModel message) {
		switch(message.getArea()){
			case CreateProtocol.Area_CreateRequest:
				break;
			default:
				break;
		}
	}
	
	public int roleCreate(SocketModel request){
		String account = "";
		
		List<String> message = request.getMessage();
		int selectIndex = Integer.parseInt(message.get(0));
		String username = message.get(1);
		return RoleManager.getInstance().insertRole(account, selectIndex, username);
	}
	
	public void createResponse(ChannelHandlerContext ctx, SocketModel request){
		SocketModel response = new SocketModel();
		int command = roleCreate(request);
		
		response.setType(Protocol.TYPE_CREATE);
		response.setArea(CreateProtocol.Area_CreateResponse);
		response.setCommand(command);
		response.setMessage(request.getMessage());
		ctx.writeAndFlush(response);
		
		if (command == CreateProtocol.Create_Succeed) {
			// TODO
		}
	}
}
