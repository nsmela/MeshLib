#pragma once

#include "MRMeshFwd.h"

using ProgressCallback = std::function<bool( float )>;

typedef bool ( *MRProgressCallback )( float progress, void* userData );

MR_EXTERN_C_BEGIN



MR_EXTERN_C_END