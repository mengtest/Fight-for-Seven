package com.FightforSeven.decoder;

import io.netty.handler.codec.LengthFieldBasedFrameDecoder;

/**
 * @author 作者：littleredhat
 * @date 创建时间：2016年11月20日 下午11:24:19
 * @version 1.0
 *
 */
public class LengthDecoder extends LengthFieldBasedFrameDecoder {

	public LengthDecoder(int maxFrameLength, int lengthFieldOffset, int lengthFieldLength, int lengthAdjustment,
			int initialBytesToStrip) {
		super(maxFrameLength, lengthFieldOffset, lengthFieldLength, lengthAdjustment, initialBytesToStrip);
	}

}
