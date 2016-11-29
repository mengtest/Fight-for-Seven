package com.FightforSeven.handler;

import java.util.List;

import com.FightforSeven.manager.RoleManager;
import com.FightforSeven.model.SocketModel;
import com.FightforSeven.protocol.AreaProtocol;
import com.FightforSeven.protocol.CommandProtocol;
import com.FightforSeven.protocol.TypeProtocol;
import com.FightforSeven.server.MainServer;

import io.netty.channel.ChannelHandlerContext;

/** 
 * @author  作者：littleredhat
 * @date 创建时间：2016年11月25日 下午1:16:40 
 * @version 1.0 
 *
 */
public class CreateRoleHandler extends BaseHandler {

	@Override
	public int getType() {
		return TypeProtocol.TYPE_CREATE_ROLE;
	}

	@Override
	public void dispatch(ChannelHandlerContext ctx, SocketModel message) {
		switch(message.getArea()){
			case AreaProtocol.Area_CreateRoleRequest:
				createRoleResponse(ctx, message);
				break;
			default:
				break;
		}
	}
	
	public int createRole(ChannelHandlerContext ctx, SocketModel request){
		String account = MainServer.getInstance().channel2account.get(ctx.channel());
		
		List<String> message = request.getMessage();
		int selectIndex = Integer.parseInt(message.get(0));
		String username = message.get(1);
		if(RoleManager.getInstance().checkUsername(username) == CommandProtocol.CreateRole_UsernameNonExist){  //用户名不存在
			return RoleManager.getInstance().insertRole(account, selectIndex, username);
		}else{
			return CommandProtocol.CreateRole_UsernameExist;
		}
	}
	
	public void createRoleResponse(ChannelHandlerContext ctx, SocketModel request){
		SocketModel response = new SocketModel();
		int command = createRole(ctx, request);
		
		response.setType(TypeProtocol.TYPE_CREATE_ROLE);
		response.setArea(AreaProtocol.Area_CreateRoleResponse);
		response.setCommand(command);
		response.setMessage(request.getMessage());
		ctx.writeAndFlush(response);
		
		if (command == CommandProtocol.CreateRole_Succeed) {
			// TODO
		}
	}
}
