package com.FightforSeven.handler;

import com.FightforSeven.manager.RoleManager;
import com.FightforSeven.model.SocketModel;
import com.FightforSeven.protocol.AreaProtocol;
import com.FightforSeven.protocol.CommandProtocol;
import com.FightforSeven.protocol.TypeProtocol;
import com.FightforSeven.server.MainServer;

import io.netty.channel.ChannelHandlerContext;

/** 
 * @author  作者：littleredhat
 * @date 创建时间：2016年11月27日 下午8:26:21 
 * @version 1.0 
 *
 */
public class GetRoleHandler extends BaseHandler {

	@Override
	public int getType() {
		return TypeProtocol.TYPE_GET_ROLE;
	}

	@Override
	public void dispatch(ChannelHandlerContext ctx, SocketModel message) {
		switch(message.getArea()){
		case AreaProtocol.Area_GetRoleRequest:
			getRoleResponse(ctx, message);
			break;
		default:
			break;
		}
	}
	
	public int checkRole(ChannelHandlerContext ctx, SocketModel request){
		String account = MainServer.getInstance().channel2account.get(ctx.channel());
		System.out.println("get role : " + account);
		return RoleManager.getInstance().checkRole(account);
	}
	
	public void getRoleResponse(ChannelHandlerContext ctx, SocketModel request){
		SocketModel response = new SocketModel();
		int command = checkRole(ctx, request);
			
		if (command == CommandProtocol.GetRole_RoleNonExist) {  //角色不存在
			response.setType(TypeProtocol.TYPE_GET_ROLE);
			response.setArea(AreaProtocol.Area_GetRoleResponse);
			response.setCommand(CommandProtocol.GetRole_RoleNonExist);
			response.setMessage(request.getMessage());
			ctx.writeAndFlush(response);
		}else{
			response.setType(TypeProtocol.TYPE_GET_ROLE);
			response.setArea(AreaProtocol.Area_GetRoleResponse);
			response.setCommand(CommandProtocol.GetRole_Succeed);
			response.setMessage(request.getMessage());
			ctx.writeAndFlush(response);
		}
	}

}
