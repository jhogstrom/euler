import random

p1wins = 0
for i in range(1000000):
	p1 = sum(random.randint(0, 4) for i in range(9))
	p2 = sum(random.randint(0, 6) for i in range(6))
	if p1 > p2:
		p1wins += 1

print p1wins