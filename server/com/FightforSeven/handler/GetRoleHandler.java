package com.FightforSeven.handler;

import java.util.ArrayList;
import java.util.List;

import com.FightforSeven.dto.Role;
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
		case AreaProtocol.Area_GetRoleResponse:
			break;
		default:
			break;
		}
	}
	
	public Role getRole(ChannelHandlerContext ctx, SocketModel request){
		String account = MainServer.getInstance().channel2account.get(ctx.channel());
		
		return RoleManager.getInstance().getRole(account);
	}
	
	public void getRoleResponse(ChannelHandlerContext ctx, SocketModel request){
		SocketModel response = new SocketModel();
		Role role = getRole(ctx, request);
			
		if (role == null) {  //角色不存在
			response.setType(TypeProtocol.TYPE_GET_ROLE);
			response.setArea(AreaProtocol.Area_GetRoleResponse);
			response.setCommand(CommandProtocol.GetRole_RoleNonExist);
			response.setMessage(request.getMessage());
			ctx.writeAndFlush(response);
		}else{
			List<String> message = new ArrayList<String>();
			message.add(Integer.toString(role.getSelectIndex()));
			message.add(role.getUsername());
			
			response.setType(TypeProtocol.TYPE_GET_ROLE);
			response.setArea(AreaProtocol.Area_GetRoleResponse);
			response.setCommand(CommandProtocol.GetRole_Succeed);
			response.setMessage(message);
			ctx.writeAndFlush(response);
		}
	}

}
