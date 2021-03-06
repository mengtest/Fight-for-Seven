package com.FightforSeven.handler;

import java.util.List;

import com.FightforSeven.manager.AccountManager;
import com.FightforSeven.model.SocketModel;
import com.FightforSeven.protocol.TypeProtocol;
import com.FightforSeven.server.MainServer;
import com.FightforSeven.protocol.AreaProtocol;
import com.FightforSeven.protocol.CommandProtocol;

import io.netty.channel.ChannelHandlerContext;

/**
 * @author 作者：littleredhat
 * @date 创建时间：2016年11月21日 上午12:20:43
 * @version 1.0
 *
 */
public class LoginHandler extends BaseHandler{
	private volatile int num = 0;
	
	@Override
	public int getType() {
		return TypeProtocol.TYPE_LOGIN;
	}

	@Override
	public void dispatch(ChannelHandlerContext ctx, SocketModel message) {
		switch (message.getArea()) {
		case AreaProtocol.Area_LoginRequest:
			loginResponse(ctx, message);
			break;
		default:
			break;
		}
	}

	public int checkAccount(SocketModel request) {
		List<String> message = request.getMessage();
		String account = message.get(0);
		String password = message.get(1);
		System.out.println(++num + " from client");
		return AccountManager.getInstance().checkAccount(account, password);
	}

	public void loginResponse(ChannelHandlerContext ctx, SocketModel request) {
		SocketModel response = new SocketModel();
		int command = checkAccount(request);
		
		response.setType(TypeProtocol.TYPE_LOGIN);
		response.setArea(AreaProtocol.Area_LoginResponse);
		response.setCommand(command);
		response.setMessage(request.getMessage());
		ctx.writeAndFlush(response);
		
		if (command == CommandProtocol.Login_Succeed) {
			MainServer.getInstance().channel2account.put(ctx.channel(), request.getMessage().get(0));  //记录登录成功的连接对应的账号
			MainServer.getInstance().account2channel.put(request.getMessage().get(0), ctx.channel());  //记录登录成功的账号对应的连接
		}
	}
	
}
