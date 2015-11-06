

#define true 1;
#define false 0;

typedef enum {
	END,
	REPEAT,
	CONTINUE
} CycleMode;

main (t)
{
	
	CycleMode cycleMode = END;
	
	int rate = 1024;
	int cnt = 0;
	int cycles = 8;
	int start = 0;
	
	int seqPos;
	static int seqSamples = 1024;
	static int seqLen = 32;
	static int seq[] = (int []){ 1,12,5,0, 1,2,4,4, 1,3,5,2, 1,12,0,0, 1,1,5,1, 1,2,4,4, 1,3,5,12, 1,5,4,5,};
	//static int seq[] = (int []){ 666,666,666,666,  666,666,666,666,  666,666,666,666,  666,666,666,666,  666,666,666,666,  666,666,666,666,  666,666,666,666,  666,666,666,666,};
	//static int seq[] = (int []){ 1,666,666,666, 1,666,666,666, 1,666,666,666, 1,666,666,666, 1,666,666,666, 1,666,666,666, 1,666,666,666, 1,666,666,666,};
	//static int seq[] = (int []){ 1,5,5,5, 1,5,4,5, 1,5,5,5, 1,5,4,5, 1,5,5,5, 1,5,4,5, 1,5,5,5, 1,5,4,5,};
	
	for(t=rate*start;;t++)
	{
		cnt++;
		//putchar(  t*(((t>>12)|(t>>8))&(19&(t>>4)))  );
		//putchar(  t*42&t>>12|t*(((t>>12)|(t>>8))&(43&(t>>4)))  );
		
		//putchar(  (t&t>>3)-15|t*(((t>>12)|(t>>8))&(42&(t>>4)))  );
		
		//putchar((19&t>>8)*t*t);
		switch (seq[(seqPos/seqSamples)%seqLen]) {
			case 0:
				putchar((19&t>>4)*t*(t%4));
				break;
			case 2:
				putchar((19&t>>2)*t*(t%8));
				break;
			case 3:
				putchar((42&t>>8)*t*(t%8));
				break;
			case 1:
				putchar((t&t>>4)-4);
				break;
			case 12:
				putchar((t&t>>4)-(t*3));
				break;
			case 4:
				putchar((19&t>>8)*t);
				break;
			case 5:
				putchar((19&t>>8)*t*2);
				break;
			default:
				putchar((t&t>>4)-(t*3));
				break;
		}

		seqPos++;

		if (seqPos/seqSamples>=seqLen)
		{
			switch (cycleMode) {
				case END:
					return 0;
					break;
				case REPEAT:
					t = rate*start;
					break;
				case CONTINUE:
					break;
			}
		}
	}
}



