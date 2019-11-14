function copyArray(src, srcIndex, dest, destIndex, length) {
    if (!Array.isArray(src) || !Array.isArray(dest)) {
        return;
    }

    if (!inRange(src, srcIndex) || !inRange(dest, destIndex) || destIndex + length > dest.length || length > src.length - srcIndex) {
        return;
    }

    for (var count = 0; count < length; destIndex++ , srcIndex++, count++) {
        dest[destIndex] = src[srcIndex];
        }

    function inRange(arr, index) {
        return index >= 0 && index < arr.length;
    }
}