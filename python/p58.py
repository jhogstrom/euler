import math

def corners(n):
	'''Returns left-up, right-up, right-down,left-down'''
	twon = 2*n
	sq = twon * twon
	#No need to calculate right-down - it's a square number! (sq + 2 * twon + 1)
	return (sq + 1, sq - twon + 1,  sq + twon + 1)

primes = [2, 3, 5, 7]
def isprime(n):
	if n < 2:
		return False
	if n in primes:
		return True
	for i in range(2, int(math.sqrt(n)) + 1):
		if (n % i) == 0:
			return False
	return True

count = 1
pc = 0
n = 1
# for n in range(1, 20):
while True:
	count += 4
	for c in corners(n):
		if isprime(c): pc += 1
	# print n, pc, count, float(pc)/count * 100
	if float(pc)/count < 0.1:
		print "Side length: ", 2*n + 1
		exit()
	n += 1

	


