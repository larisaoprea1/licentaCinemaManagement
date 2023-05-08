export function dateCheck(from, to, check) {
  var fDate, lDate, cDate;
  fDate = Date.parse(from);
  lDate = Date.parse(to);
  cDate = Date.parse(check);

  if (cDate <= lDate && cDate >= fDate) {
    return true;
  }
  return false;
}
