package com.FightforSeven.handler;

import java.util.List;

import com.FightforSeven.manager.AccountManager;
import com.FightforSeven.model.SocketModel;
import com.FightforSeven.protocol.Protocol;
import com.FightforSeven.protocol.RegisterProtocol;

import io.netty.channel.ChannelHandlerContext;

/**
 * @author 作者：littleredhat
 * @date 创建时间：2016年11月21日 下午10:03:25
 * @version 1.0
 *
 */
public class RegisterHandler {
	private static RegisterHandler instance = new RegisterHandler();

	public static RegisterHandler getInstance() {
		return instance;
	}

	public void dispatch(ChannelHandlerContext ctx, SocketModel message) {
		switch (message.getArea()) {
		case RegisterProtocol.Area_RegisterRequest:
			registerResponse(ctx, message);
			break;
		default:
			break;
		}
	}

	public int registerCheck(ChannelHandlerContext ctx, SocketModel request) {
		List<String> message = request.getMessage();
		String account = message.get(0);
		String password = message.get(1);
		return AccountManager.getInstance().insertAccount(account, password);
	}

	public void registerResponse(ChannelHandlerContext ctx, SocketModel request) {
		SocketModel response = new SocketModel();
		int command = registerCheck(ctx, request);
		
		response.setType(Protocol.TYPE_REGISTER);
		response.setArea(RegisterProtocol.Area_RegisterResponse);
		response.setCommand(command);
		response.setMessage(request.getMessage());
		ctx.writeAndFlush(response);
		
		if (command == RegisterProtocol.Register_Succeed) {
			// TODO
		}
	}
}
