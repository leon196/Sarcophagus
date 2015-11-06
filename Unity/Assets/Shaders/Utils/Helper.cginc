
float kaleido (float x, float t)
{
    x += t * lerp(-1.0, 1.0, fmod(floor(abs(x)), 2.0));
    float xMod = fmod(abs(x), 1.0);
    return lerp(1.0 - xMod, xMod, fmod(floor(abs(x)), 2.0));
}

// http://stackoverflow.com/questions/12964279/whats-the-origin-of-this-glsl-rand-one-liner
float rand(float2 co)
{
  return frac(sin(dot(co.xy ,float2(12.9898,78.233))) * 43758.5453);
}