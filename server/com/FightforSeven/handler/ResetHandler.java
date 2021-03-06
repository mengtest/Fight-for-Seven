package com.FightforSeven.handler;

import java.util.List;

import com.FightforSeven.manager.AccountManager;
import com.FightforSeven.model.SocketModel;
import com.FightforSeven.protocol.AreaProtocol;
import com.FightforSeven.protocol.CommandProtocol;
import com.FightforSeven.protocol.TypeProtocol;

import io.netty.channel.ChannelHandlerContext;

/**
 * @author 作者：littleredhat
 * @date 创建时间：2016年11月21日 下午10:03:25
 * @version 1.0
 *
 */
public class ResetHandler extends BaseHandler{
	
	@Override
	public int getType() {
		return TypeProtocol.TYPE_RESET;
	}

	@Override
	public void dispatch(ChannelHandlerContext ctx, SocketModel message) {
		switch (message.getArea()) {
		case AreaProtocol.Area_ResetRequest:
			resetResponse(ctx, message);
			break;
		default:
			break;
		}
	}

	public int resetCheck(SocketModel request) {
		List<String> message = request.getMessage();
		String account = message.get(0);
		String password = message.get(1);
		String password_new = message.get(2);
		return AccountManager.getInstance().updateAccount(account, password, password_new);
	}

	public void resetResponse(ChannelHandlerContext ctx, SocketModel request) {
		SocketModel response = new SocketModel();
		int command = resetCheck(request);
		
		response.setType(TypeProtocol.TYPE_RESET);
		response.setArea(AreaProtocol.Area_ResetResponse);
		response.setCommand(command);
		response.setMessage(request.getMessage());
		ctx.writeAndFlush(response);
		
		if (command == CommandProtocol.Reset_Succeed) {
			// TODO
		}
	}
	
}
