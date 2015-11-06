
float kaleido (float x, float t)
{
    x += t * lerp(-1.0, 1.0, fmod(floor(abs(x)), 2.0));
    float xMod = fmod(abs(x), 1.0);
    return lerp(1.0 - xMod, xMod, fmod(floor(abs(x)), 2.0));
}