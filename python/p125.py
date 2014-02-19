n, squares, answer, MAXSUM, answerset = 0, [], 0, 1e8, set()

while True:
	n +=1
	sq = n ** 2
	if sum(squares[-1:]) + sq > MAXSUM:
	 	break
	squares.append(sq)

for i in range(len(squares)-1):
	for j in range(i+2, len(squares)):
		s = sum(squares[i:j])
		if s > MAXSUM:
			break
		if str(s) == str(s)[::-1]:
			answerset.add(s)

print "Answer:", sum(answerset)
#2906969179