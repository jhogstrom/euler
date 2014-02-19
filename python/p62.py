MAX, PERMS, counter=1000000, 5, {}

for i in xrange(MAX):
	icube = i **3
	s = "".join(sorted(list(str(icube))))
	if not counter.has_key(s):
		counter[s] = [0, icube, []]
	counter[s][0] += 1
	counter[s][2].append(icube)

	if counter[s][0] == PERMS:
		break

print max(counter.values())