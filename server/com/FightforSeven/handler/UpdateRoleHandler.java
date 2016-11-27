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
 * @author  ���ߣ�littleredhat
 * @date ����ʱ�䣺2016��11��27�� ����8:26:37 
 * @version 1.0 
 *
 */
public class UpdateRoleHandler extends BaseHandler {

	@Override
	public int getType() {
		return TypeProtocol.TYPE_UPDATE_ROLE;
	}

	@Override
	public void dispatch(ChannelHandlerContext ctx, SocketModel message) {
		switch(message.getArea()){
		case AreaProtocol.Area_UpdateRoleResponse:
			updateUsernameResponse(ctx, message);
			break;
		default:
			break;
	}
	}
	
	public int updateUsername(ChannelHandlerContext ctx, SocketModel request){
		String account = MainServer.getInstance().channel2account.get(ctx.channel());
		
		List<String> message = request.getMessage();
		String username = message.get(0);
		return RoleManager.getInstance().updateUsername(account, username);
	}
	
	public void updateUsernameResponse(ChannelHandlerContext ctx, SocketModel request){
		SocketModel response = new SocketModel();
		int command = updateUsername(ctx, request);
		
		response.setType(TypeProtocol.TYPE_UPDATE_ROLE);
		response.setArea(AreaProtocol.Area_UpdateRoleResponse);
		response.setCommand(command);
		response.setMessage(request.getMessage());
		ctx.writeAndFlush(response);
		
		if (command == CommandProtocol.UpdateRole_Succeed) {
			// TODO
		}
	}

}
