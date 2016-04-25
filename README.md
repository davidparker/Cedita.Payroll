# Cedita.Payroll

Cedita.Payroll is a set of HMRC-Compliant C# PAYE, NI, etc calculators to be used by payroll solution builders as a base for their systems.

Tests are provided from HMRC to validate conformity to specifications.

### :exclamation: Important Known Issues
- National Insurance does not support 2016/17 tax year (see #2)
- National Insurance does not support cumulative (see #1)

### Future Plans
At time of writing, the codebase is fairly tailored to how we needed to use it in our specific application (ie. static and rather limited), as time goes on we will be
refactoring the codebase in many ways to assist with implementation in other systems.