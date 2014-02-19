MAX = 1000
squares = dict([(n, n**2) for n in range(MAX)])
sqrev = dict([n**2, n] for n in range(MAX))
perimeters = dict([n, [0, []]] for n in range(MAX+1))

for a in range(1, MAX / 2):
	for b in range(1, MAX / 2):
		ab_sq = squares[a] + squares[b]#a**2 + b**2
		if sqrev.has_key(ab_sq):
			c = sqrev[ab_sq]
			p = a + b + c
			if p % 2 == 0 and p <= MAX:
				p_set = {a, b, c}

				if not p_set in  perimeters[p][1]:
					perimeters[p][0] += 1
					perimeters[p][1].append(p_set)

m = max(perimeters.values())
print m[0], sum(m[1][0])

"hej"